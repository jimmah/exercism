class Bob {
  hey(input: string): string {
    if (this.isSilence(input)) {
      return "Fine. Be that way!"
    }
    if (this.isShouting(input)) {
      return "Whoa, chill out!"
    }
    if (this.isQuestion(input)) {
      return "Sure."
    }

    return "Whatever."
  }

  private isSilence(input: string): boolean {
    if (typeof input === "undefined" || input === undefined) {
      return true
    }
    return input.replace(/\s/g, "").length < 1
  }

  private isQuestion(input: string): boolean {
    return input.endsWith("?")
  }

  private isShouting(input: string): boolean {
    return input === input.toUpperCase() && /[a-zA-Z]+/.test(input)
  }
}

export default Bob
