const path = require('path')
const fs = require('fs')
const child_process = require('child_process')

const root = process.cwd()
npmInstallRecursive(root)

console.log('===================================================================')
console.log(`Performing "npm install" inside root folder`)
console.log('===================================================================')

function npmInstallRecursive(folder) {
  const hasPackageJson = fs.existsSync(path.join(folder, 'package.json'))

  if (hasPackageJson && folder !== root) {
    console.log('===================================================================')
    console.log(`Performing "npm install" inside ${folder === root ? 'root folder' : './' + path.relative(root, folder)}`)
    console.log('===================================================================')

    npmInstall(folder)
  }

  for (let subFolder of subfolders(folder)) {
    npmInstallRecursive(subFolder)
  }
}

function npmInstall(folder) {
  child_process.execSync('npm install', { cwd: folder, env: process.env, stdio: 'inherit' })
}

function subfolders(folder) {
  return fs.readdirSync(folder)
    .filter(x => fs.statSync(path.join(folder, x)).isDirectory())
    .filter(x => x !== 'node_modules' && x[0] !== '.')
    .map(x => path.join(folder, x))
}
