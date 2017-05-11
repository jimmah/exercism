class PhoneNumber {
  private _phoneNumber: string

  constructor(phoneNumber: string) {
    this._phoneNumber = phoneNumber.replace(/(\)|\(|\s|\.|-)/g, "")
    if (this._phoneNumber.length === 11 && this._phoneNumber[0] === "1") {
      this._phoneNumber = this._phoneNumber.slice(1, 11)
    }
  }

  number(): string | undefined {
    if (this._phoneNumber.length < 10 || this._phoneNumber.length > 10) {
      return undefined
    }

    return this._phoneNumber.split("").filter((c) => isNaN(parseInt(c, 10))).length > 0
      ? undefined
      : this._phoneNumber
  }
}

export default PhoneNumber
