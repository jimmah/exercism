class GradeSchool {
  private _students = new Map<number, Set<string>>()

  addStudent(name: string, grade: number) {
    const students = this._students.get(grade) || new Set<string>()
    students.add(name)
    this._students.set(grade, students)
  }

  studentRoster(): Map<string, string[]> {
    const result = new Map<string, string[]>()

    const grades: number[] = Array.from(this._students.keys()).sort()

    for (const grade of grades) {
      const students = this._students.get(grade) || new Set<string>()
      result.set(grade.toString(), Array.from(students).sort())
    }

    return result
  }

  studentsInGrade(grade: number): string[] {
    return Array.from(this._students.get(grade) || new Set<string>()).sort()
  }
}

export default GradeSchool
