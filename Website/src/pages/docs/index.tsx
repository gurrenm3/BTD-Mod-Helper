import { GetStaticProps } from "next";
import { useEffect } from "react";
import { useRouter } from "next/router";
import { MarkdownLayout } from "../../components/markdown-layout";

export default () => {
  const router = useRouter();

  useEffect(() => {
    router.replace("/docs/README");
  }, []);

  return (
    <MarkdownLayout data={undefined} noTitle={true}>
      <div style={{ height: 500 }} />
    </MarkdownLayout>
  );
};
