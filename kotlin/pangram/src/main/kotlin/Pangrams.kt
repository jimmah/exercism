object Pangrams {
    fun isPangram(input: String) = input.toLowerCase().replace(Regex("[^a-z]"), "").toSet().size == 26
}