package clock

import "fmt"

const testVersion = 4

// Clock is an integer...
type Clock int

// New creates a new Clock
func New(hour, minute int) Clock {
	clock := Clock((hour*60 + minute) % 1440)
	if clock < 0 {
		clock += 1440
	}
	return clock
}

// Add adds the specified number of minutes to the clock
func (clock Clock) Add(minutes int) Clock {
	return New(0, int(clock)+minutes)
}

func (clock Clock) String() string {
	return fmt.Sprintf("%02d:%02d", clock/60, clock%60)
}
