# Portfolio Projects - Clippit

This is a basic

## Table of contents

- [Overview](#overview)
  - [Project Requirements](#Project-Requirements)
  - [Screenshots](#screenshots)
  - [Links](#links)
- [My process](#my-process)
  - [What I learned](#what-i-learned)
  - [Useful resources](#useful-resources)

## Overview

### Project Requirements

- Data Base Integration and Information Retrieval
- Unique ID Generator (1000 - 9999) 
- Error Checking
- Appealing / Responsive Layout

### Screenshots

<img src="https://user-images.githubusercontent.com/101738608/197719421-a2647341-fe8b-4753-b377-5989eec35c6c.png" width="500">

### Links

* Site URL: [@Somee](http://clippit.somee.com/)

### What I learned

- This is my way to display dynamic divider between the second, third (and so on) card but not on the last one:

```css
.card {
  padding: 2em 0;
}

.cards-list > .card + .card {
  padding: 2em 0;
  border-top: 1px solid var(--clr-text-light);
}

.cards-list .card:first-child {
  padding-top: 0;
}

.cards-list .card:last-child {
  padding-bottom: 0;
}
```

- How to implement dark mode via CSS:

```css
@media (prefers-color-scheme: light) {
  :root {
    --clr-text-main: #2b283a;
    --clr-text-light: #918e9b;

    --clr-background-light: #ffffff;
  }
}

/* Dark Mode */

@media (prefers-color-scheme: dark) {
  :root {
    --clr-text-main: #fff;
    --clr-text-light: #e5e5e5;

    --clr-background-light: #1d1d1c;
  }
}
```

### Useful resources

- [ReactJS](https://reactjs.org/tutorial/tutorial.html) - How to set up a local development environment on your computer
- [FontAwesome](https://fontawesome.com/v5/docs/web/use-with/react) - How to install FontAwesome packages for React -[BobbyHadz](https://bobbyhadz.com/blog/react-assign-object-to-variable-before-exporting-as-module) - Assign object to variable before exporting as module default
- [Developer Mozilla](https://developer.mozilla.org/en-US/docs/Web/CSS/@media/prefers-color-scheme) - Detect if the user has requested a light or dark color theme
