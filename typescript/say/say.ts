class Say {
  private _translations = new Map<number, string>([
    [0, 'zero'],
    [1, 'one'],
    [2, 'two'],
    [3, 'three'],
    [4, 'four'],
    [5, 'five'],
    [6, 'six'],
    [7, 'seven'],
    [8, 'eight'],
    [9, 'nine'],
    [10, 'ten'],
    [11, 'eleven'],
    [12, 'twelve'],
    [13, 'thirteen'],
    [14, 'fourteen'],
    [15, 'fifteen'],
    [16, 'sixteen'],
    [17, 'seventeen'],
    [18, 'eighteen'],
    [19, 'nineteen'],
    [20, 'twenty'],
    [30, 'thirty'],
    [40, 'forty'],
    [50, 'fifty'],
    [60, 'sixty'],
    [70, 'seventy'],
    [80, 'eighty'],
    [90, 'ninety'],
    [100, 'hundred'],
    [1000, 'thousand'],
    [1000000, 'million'],
    [1000000000, 'billion']
  ])

  inEnglish(num: number): string {
    if (num < 0 || num > 999999999999) {
      throw new Error('Number must be between 0 and 999,999,999,999.')
    }

    return this.convert(num)
  }

  private convert(num: number): string {
    if (num < 100) {
      return this.underOneHundred(num)
    }

    const scale = this.getScale(num)
    const scaled = this.applyScale(num, scale)
    const remainder = num % scale

    let result = scaled === 0 ? "" : `${this.convert(scaled)} ${this._translations.get(scale)!}`
    result += remainder === 0 ? "" : ` ${this.convert(remainder)}`
    return result
  }

  private underOneHundred(num: number): string {
    if (num > 100) {
      throw new Error(`underOneHundred only accepts values 0 to 99`)
    }

    if (num <= 20) {
      return this._translations.get(num)!
    }

    if (num > 20 && num < 100 ) {
      const scaled = this.applyScale(num, 10) * 10
      const tens  = this._translations.get(scaled)!
      const remainder = this._translations.get(num % scaled)!

      return `${tens}-${remainder}`
    }

    return ""
  }

  private getScale(num: number): number {
    if (num >= 100 && num < 1000 ) {
        return 100
    }

    if (num < 1000000 && num >= 1000) {
        return 1000
    }

    if (num < 1000000000 && num >= 1000000) {
        return 1000000
    }

    if (num < 1000000000000 && num >= 1000000000) {
        return 1000000000
    }

    throw new Error(`getScale only accepts values between 100 to 1000000000000 - 1`)
  }

  private applyScale(num: number, scale: number): number {
    return ((num / scale) | 0)
  }
}

export default Say
