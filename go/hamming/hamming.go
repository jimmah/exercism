package hamming

import "errors"

const testVersion = 5

// Distance calculates the hamming distance for two strands of DNA
func Distance(a, b string) (d int, err error) {
	if len(b) != len(a) {
		return 0, errors.New("Provided DNA strands have different lengths")
	}

	for i := 0; i < len(a); i++ {
		if a[i] != b[i] {
			d++
		}
	}

	return
}
