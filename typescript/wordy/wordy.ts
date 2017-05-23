class WordProblem {
  private _question: string

  constructor(question: string) {
    this._question = question
  }

  answer(): number {
    type Operation = (a: number, b: number) => number
    const operations: {[key: string]: Operation} = {
      plus: (a: number, b: number) => { return a + b },
      minus: (a: number, b: number) => { return a - b },
      multiplied: (a: number, b: number) => { return a * b },
      divided: (a: number, b: number) => { return a / b }
    }

    const question = this._question
      .replace(/by /g, "")
      .replace("What is ", "")
      .replace("?", "")

    const parts = question.split(" ")

    let result = 0

    if (parts.length < 3 || parts.length > 5) {
      throw new ArgumentError()
    }

    if (parts.length >= 3) {
      const a = parts[0]
      const op: Operation = operations[parts[1]]
      const b = parts[2]

      if (op === undefined) {
        throw new ArgumentError()
      }

      result = op(+a, +b)
    }

    if (parts.length === 5) {
      const op: Operation = operations[parts[3]]
      const x = parts[4]

      if (op === undefined) {
        throw new ArgumentError()
      }

      result = op(result, +x)
    }

    return result
  }
}

class ArgumentError {}

export {WordProblem, ArgumentError}
