fun transcribeToRna(dna: String): String = dna.map { nucleotide ->
  when (nucleotide) {
    'G' -> 'C'
    'C' -> 'G'
    'T' -> 'A'
    'A' -> 'U'
    else -> ""
  }
}.joinToString("")
