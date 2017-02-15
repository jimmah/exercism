const transforms = {
  G: "C",
  C: "G",
  T: "A",
  A: "U"
};

class Transcriptor {
  toRna(dna) {
    let rna = dna.replace(/./g, x => transforms[x]);

    if (rna.length !== dna.length) {
      throw new Error("Invalid input DNA.");
    }

    return rna;
  }
}

export default Transcriptor;
