class Transcriptor {
  toRna(dna: string): string {
    const transforms: { [key: string]: string} = {
      G: "C",
      C: "G",
      T: "A",
      A: "U"
    }

    const rna = dna.replace(/./g, (x) => transforms[x])

    if (rna.length !== dna.length) {
      throw new Error("Invalid input DNA.")
    }

    return rna
  }
}

export default Transcriptor
