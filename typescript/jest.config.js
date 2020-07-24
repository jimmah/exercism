module.exports = {
  "testMatch": [
    "**/__tests__/**/*.[jt]s?(x)",
    "**/test/**/*.[jt]s?(x)",
    "**/?(*.)+(spec|test).[jt]s?(x)"
  ],
  "testPathIgnorePatterns": [
    '/(?:production_)?node_modules/',
    '.d.ts$',
    '__mocks__'
  ],
  "transform": {
    '^.+\\.[jt]sx?$': 'ts-jest',
  }
}
