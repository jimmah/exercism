class HelloWorld {
  hello(name) {
    if (name === undefined || name === '') {
      name = 'World';
    }

    return `Hello, ${name}!`;
  }
}

export default HelloWorld;
