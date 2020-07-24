const transforms = {
  G: "C",
  C: "G",
  T: "A",
  A: "U"
};

export const toRna = (dna) => dna.replace(/./g, x => transforms[x])
