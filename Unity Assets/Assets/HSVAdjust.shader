Shader "Custom/HSVAdjust"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TargetColor ("Target Color", Color) = (1,1,1,1)
        _Threshold ("Threshold", Range(0,1)) = 1

        _HueAdjust ("Hue Adjust", Range(-180,180)) = 0
        _SaturationAdjust ("Saturation Adjust", Range(-1,1)) = 0
        _ValueAdjust ("Value Adjust", Range(-1,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _TargetColor;
            float _Threshold;

            float _HueAdjust;         // In degrees (-180 to 180)
            float _SaturationAdjust;  // Range (-1 to 1)
            float _ValueAdjust;       // Range (-1 to 1)

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Helper functions for RGB <-> HSV conversions
            float3 RGBToHSV(float3 rgb)
            {
                float r = rgb.r;
                float g = rgb.g;
                float b = rgb.b;

                float maxc = max(r, max(g, b));
                float minc = min(r, min(g, b));
                float delta = maxc - minc;

                float h = 0.0;
                float s = 0.0;
                float v = maxc;

                if (delta > 0.0001)
                {
                    s = delta / maxc;

                    if (r == maxc)
                    {
                        h = (g - b) / delta;
                    }
                    else if (g == maxc)
                    {
                        h = 2.0 + (b - r) / delta;
                    }
                    else
                    {
                        h = 4.0 + (r - g) / delta;
                    }

                    h = h * 60.0;
                    if (h < 0.0)
                        h += 360.0;
                }

                return float3(h, s, v);
            }

            float3 HSVToRGB(float3 hsv)
            {
                float h = hsv.x;
                float s = hsv.y;
                float v = hsv.z;

                if (s <= 0.0)
                {
                    return float3(v, v, v);
                }

                h = h / 60.0;
                int sector = (int)floor(h);
                float fraction = h - sector;
                float p = v * (1.0 - s);
                float q = v * (1.0 - s * fraction);
                float t = v * (1.0 - s * (1.0 - fraction));

                float3 rgb;

                if (sector == 0)
                    rgb = float3(v, t, p);
                else if (sector == 1)
                    rgb = float3(q, v, p);
                else if (sector == 2)
                    rgb = float3(p, v, t);
                else if (sector == 3)
                    rgb = float3(p, q, v);
                else if (sector == 4)
                    rgb = float3(t, p, v);
                else
                    rgb = float3(v, p, q);

                return rgb;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.uv);
                float3 originalColor = texColor.rgb;

                if (_Threshold == 1 || distance(originalColor, _TargetColor.rgb) <= _Threshold)
                {
                    // Convert RGB to HSV
                    float3 hsv = RGBToHSV(originalColor);

                    // Adjust Hue
                    hsv.x += _HueAdjust;
                    if (hsv.x > 360.0)
                        hsv.x -= 360.0;
                    else if (hsv.x < 0.0)
                        hsv.x += 360.0;

                    // Adjust Saturation
                    hsv.y += _SaturationAdjust;
                    hsv.y = clamp(hsv.y, 0.0, 1.0);

                    // Adjust Value (Brightness)
                    hsv.z += _ValueAdjust;
                    hsv.z = clamp(hsv.z, 0.0, 1.0);

                    // Convert back to RGB
                    float3 adjustedColor = HSVToRGB(hsv);

                    texColor.rgb = adjustedColor;
                }

                return texColor;
            }
            ENDCG
        }
    }
}
