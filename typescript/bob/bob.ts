class Bob {
  hey(input: string): string {
    if (this.isShouting(input) && this.isQuestion(input)) {
      return "Calm down, I know what I'm doing!"
    }
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
    return input.trim().endsWith("?")
  }

  private isShouting(input: string): boolean {
    return input === input.toUpperCase() && /[a-zA-Z]+/.test(input)
  }
}

export default Bob
