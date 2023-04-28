export const getColor = (user: string) => {
  switch (user) {
    case "doombubbles":
      return "rgba(200, 0, 255, 255)";
    case "gurrenm3":
      return "rgba(200, 150, 255, 255)";
    default:
      return "white";
  }
};
