class Words {
  count(input: string): Map<string, number> {
    const words = input.toLowerCase().replace(/\n/m, " ").replace(/\t/m, " ").split(" ")
    const result = new Map<string, number>()

    for (const word of words) {
      if (word === "") {
        continue
      }

      const count = result.get(word) || 0
      result.set(word.trim(), count + 1)
    }

    return result
  }
}

export default Words
