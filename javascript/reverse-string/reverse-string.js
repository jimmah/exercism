export const reverseString = (input) => {
  let result = ""
  for (let i = input.length - 1; i >= 0; i -= 1) {
    result += input[i]
  }

  return result
}
