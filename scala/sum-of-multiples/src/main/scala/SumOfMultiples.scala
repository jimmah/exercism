object SumOfMultiples {
  def sumOfMultiples(factors: Set[Int], limit: Int): Int = {
    var sum = (for (s <- factors) yield (1 until limit).filter(n => n % s == 0).toSet).flatten.sum
    sum
  }
}
