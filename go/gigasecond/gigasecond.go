package gigasecond

import "time"

const testVersion = 4

// AddGigasecond returns time t + 1 gigasecond
func AddGigasecond(t time.Time) time.Time {
	return t.Add(1e9 * time.Second)
}
