object Hamming {
    fun compute(leftStrand: String, rightStrand: String): Int {
        require(leftStrand.length == rightStrand.length, {"leftStrand and rightStrand must be of equal length."})

        val pairs = leftStrand.zip(rightStrand)
        return pairs.count {it.first != it.second}
    }
}