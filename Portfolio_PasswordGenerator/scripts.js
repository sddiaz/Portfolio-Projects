// Initialize necessary variables 

const sliderValue = document.getElementById("sliderValue"); 
const sliderInput = document.getElementById("sliderInput"); 
// Grab ASCII code range for every selection 
const upperCaseCodes = getAvailableCharacters(65, 90); 
const lowerCaseCodes = getAvailableCharacters(97, 122); 
const symbolCodes1 = getAvailableCharacters(33, 47);
const symbolCodes2 = getAvailableCharacters(58, 126); 
const symbolCodes = symbolCodes1.concat(symbolCodes2);
const numberCodes = getAvailableCharacters(48, 57); 
var possibleCharacters;

sliderInput.oninput = (() => {
  let value = sliderInput.value; 
  sliderValue.textContent = value; 
  sliderValue.style.left = (value/2) + "%"
});
function copyToClipboard() {   
  // Grab our element
  var passwordText = document.getElementById("passwordBox");
  // Select the text in element
  passwordText.select();
  passwordText.setSelectionRange(0, 99999); 
   // Copy the text top clipboard
  navigator.clipboard.writeText(passwordText.value);
}
function reversePass() {
  var passwordText = document.getElementById("passwordBox").value;
  var splitString = passwordText.split(""); 
  var reversedString = splitString.reverse(); 
  var joinedString = reversedString.join(""); 
  passwordBox.value = joinedString;

}



//
function generateClick() {
  // Grab all necessary checkboxes & form variables 
  var upperCase = document.getElementById("upperCase"); 
  var lowerCase = document.getElementById("lowerCase"); 
  var symbols = document.getElementById("symbols"); 
  var numbers = document.getElementById("numbers"); 

  const includeUppercase = upperCase.checked; 
  const includeLowercase = lowerCase.checked; 
  const includeSymbols = symbols.checked; 
  const includeNumbers = numbers.checked; 
  const characterAmount = sliderInput.value; 
  if (!includeUppercase && !includeLowercase && !includeNumbers && !includeSymbols) {
    alert('You need at least one setting switch enabled.')
  }
  else {
    // generate 
    possibleCharacters = getPossibleChars(characterAmount, includeUppercase, includeLowercase, 
    includeSymbols, includeNumbers);
    const numberOfGuesses = Math.pow(possibleCharacters, characterAmount);
    // display
    const password = generatePass(characterAmount, includeUppercase, includeLowercase, 
      includeSymbols, includeNumbers);
    const passwordBox = document.getElementById("passwordBox");
    passwordBox.value = password;
  }
}
function generatePass(characterAmount, includeUppercase, includeLowercase, 
  includeSymbols, includeNumbers) {
    let charCodes = []; 
    if (includeUppercase) {
      charCodes = charCodes.concat(upperCaseCodes);
    }
    if (includeLowercase) {
      charCodes = charCodes.concat(lowerCaseCodes);
    }
    if (includeSymbols) {
      charCodes = charCodes.concat(symbolCodes);
    }
    if (includeNumbers) {
      charCodes = charCodes.concat(numberCodes);
    }
    possibleCharacters = charCodes.length;
    const passwordCharacters = []; 
    for (let i = 0; i < characterAmount; i++) {
      const characterCode = charCodes[Math.floor(Math.random() * charCodes.length)];
      passwordCharacters.push(String.fromCharCode(characterCode));
    }
    return passwordCharacters.join('');
}
function getAvailableCharacters(low, high) {
  const array = []; 
  for (let i = low; i<= high; i++) {
    array.push(i); 
  }
  return array; 
}

function checkInputs(inputBox) {
  // Grab the element we clicked and the checked status of all elements. 
  var element = document.getElementById(inputBox.id);
  const includeUppercase = upperCase.checked; 
  const includeLowercase = lowerCase.checked; 
  const includeSymbols = symbols.checked; 
  const includeNumbers = numbers.checked; 
  // We need at least one clicked element at all times
  var allElements = 4; 
  if (!includeUppercase) {
    allElements--; 
  }
  if (!includeLowercase) {
    allElements--; 
  }
  if (!includeSymbols) {
    allElements--; 
  }
  if (!includeNumbers) {
    allElements--; 
  }
  console.log(allElements);
  // If unclicking our current element would set 
  // clickedElements to 0, don't unclick it. 
  // Call events for alert box and disable clicking everywhere else.
  if (allElements == 0) {
    element.checked = true;
    var alertBox = document.getElementById("alertMessage");
    var closeBtn = document.getElementById("closeBtn");
    document.getElementsByTagName("body")[0].style.pointerEvents = "none"; 
    alertBox.style.visibility = "visible";
    closeBtn.style.visibility = "visible";
    alertBox.style.boxShadow = "0 0 0 100vmax rgba(0,0,0,.3)";
    alertBox.style.pointerEvents = "all"; 
  }
}
function closeAlert(closeBtn) {
  closeBtn.style.visibility="hidden";
  closeBtn.parentElement.style.visibility="hidden";
  document.getElementsByTagName("body")[0].style.pointerEvents = "all"; 
}
function getPossibleChars(characterAmount, includeUppercase, includeLowercase, 
  includeSymbols, includeNumbers){
    let charCodes = []; 
    if (includeUppercase) {
      charCodes = charCodes.concat(upperCaseCodes);
    }
    if (includeLowercase) {
      charCodes = charCodes.concat(lowerCaseCodes);
    }
    if (includeSymbols) {
      charCodes = charCodes.concat(symbolCodes);
    }
    if (includeNumbers) {
      charCodes = charCodes.concat(numberCodes);
    }
    possibleCharacters = charCodes.length;
    return possibleCharacters;
  }