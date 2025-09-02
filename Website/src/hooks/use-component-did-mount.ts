import { useRef } from "react";

export default function useComponentDidMount(func) {
  const willMount = useRef(true);

  if (willMount.current) {
    func();
  }

  willMount.current = false;
}
