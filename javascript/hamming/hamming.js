export const compute = (a, b) => {
  if (!a.length && b.length) {
    throw new Error("left strand must not be empty")
  }
  if (a.length && !b.length) {
    throw new Error("right strand must not be empty")
  }
  if (a.length !== b.length) {
    throw new Error("left and right strands must be of equal length")
  }

  return [...a].filter((x, i) => x !== b[i]).length;
}
