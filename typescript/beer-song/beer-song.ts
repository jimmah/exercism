class Beer {
  private static _verseForms: {[key: number]: string} = {
    0: `No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.
`,
    1: `1 bottle of beer on the wall, 1 bottle of beer.
Take it down and pass it around, no more bottles of beer on the wall.
`,
    2: `2 bottles of beer on the wall, 2 bottles of beer.
Take one down and pass it around, 1 bottle of beer on the wall.
`
  }

  static verse(count: number): string {
    if (this._verseForms[count] === undefined) {
      return `${count} bottles of beer on the wall, ${count} bottles of beer.
Take one down and pass it around, ${count - 1} bottles of beer on the wall.
`
    } else {
      return this._verseForms[count]
    }
  }

  static sing(start = 99, end = 0): string {
    const verses = []
    for (let i = start; i >= end; i--) {
      verses.push(this.verse(i))
    }

    return verses.join('\n')
  }
}

export default Beer
