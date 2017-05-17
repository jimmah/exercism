function transform(input: {[key: string]: string[]}): {[key: string]: number} {
  const result: {[key: string]: number} = {}

  for (const key in input) {
    if (input.hasOwnProperty(key)) {
      const value = input[key]
      for (const item of value) {
        result[item.toLowerCase()] = parseInt(key, 10)
      }
    }
  }

  return result
}

export default transform
