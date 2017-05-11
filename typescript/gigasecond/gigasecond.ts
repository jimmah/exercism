class Gigasecond {
  private _date: Date

  constructor(date: Date) {
    this._date = date
  }

  date(): Date {
    return new Date(this._date.valueOf() + 1e12)
  }
}

export default Gigasecond
