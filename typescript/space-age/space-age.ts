class SpaceAge {
  private _seconds: number

  constructor(seconds: number) {
    this._seconds = seconds
  }

  get seconds(): number {
    return this._seconds
  }

  public onEarth(): number {
    return this.calculateAge(1.0)
  }

  public onMercury(): number {
    return this.calculateAge(0.2408467)
  }

  public onVenus(): number {
    return this.calculateAge(0.61519726)
  }

  public onMars(): number {
    return this.calculateAge(1.8808158)
  }

  public onJupiter(): number {
    return this.calculateAge(11.862615)
  }

  public onSaturn(): number {
    return this.calculateAge(29.447498)
  }

  public onUranus(): number {
    return this.calculateAge(84.016846)
  }

  public onNeptune(): number {
    return this.calculateAge(164.79132)
  }

  private calculateAge(factor: number): number {
    const age = this._seconds / (31557600 * factor)
    return Math.round(age * 100) / 100
  }
}

export default SpaceAge
