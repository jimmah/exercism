class Bob {
  def hey(input: String): String = input match {
    case IsShouting() => "Whoa, chill out!"
    case IsQuestion() => "Sure."
    case IsSilence() => "Fine. Be that way!"
    case _ => "Whatever."
  }

  case object IsSilence {
    def unapply(input: String) = input.trim.isEmpty
  }

  case object IsQuestion {
    def unapply(input: String) = input.endsWith("?")
  }

  case object IsShouting {
    def unapply(input: String) =
      input == input.toUpperCase && input.matches(".*[A-Z].*")
  }
}