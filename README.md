# Welcome to the WyamStore

## Purpose
This repository is an example of an e-Commerce store built using [Wyam](https://wyam.io/), a static content generator and toolkit.

## Rules of the Repository
* Master branch is production, period.
* Do not commit to master, please work off the development branch.
* When working locally, try to work in feature branches.
* Please follow GitFlow.
* You may fork this repository freely, for personal or commerical use. It would be cool if you dropped my name in some credits, but it's not required.

# Setup
This site is using the [SolidState Theme](https://wyam.io/recipes/blog/themes/solidstate). If you would like to change the theme, you can do so in the `config.wyam` file by specifying `#t [themeName]`.

## How to Run
### Preview Mode
* After cloning this repo, you can build this site and see a preview of it with the following command:
`wyam build -p`

Alternatively, you can simpily execute the PowerShell script: `build.ps1`.

### Production Mode
`wyam build`