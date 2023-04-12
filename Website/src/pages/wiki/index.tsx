import { useRouter } from "next/router";
import { useEffect } from "react";
import { MarkdownLayout } from "../../components/markdown-layout";

export default () => {
  const router = useRouter();

  useEffect(() => {
    router.replace("/wiki/Home");
  }, []);

  return (
    <MarkdownLayout data={undefined} noTitle={true}>
      <div style={{ height: 500 }} />
    </MarkdownLayout>
  );
};
