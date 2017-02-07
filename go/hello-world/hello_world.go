package greeting

const testVersion = 3

// HelloWorld does Hello World, surprisingly
func HelloWorld(name string) string {
	if name == "" {
		name = "World"
	}

	return "Hello, " + name + "!"
}
