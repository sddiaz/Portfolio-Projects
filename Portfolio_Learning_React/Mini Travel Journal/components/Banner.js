import React from "react"
export default function Banner() {
    return (
      <div className="banner">
       <input id="secretButton" onClick={changeMode} className="banner--img" type="image" src="https://gcdnb.pbrd.co/images/7OnyNISqWsnH.png?o=1" height="20px" />
        <h1 className="banner--title">my travel journal.</h1>
      </div>  
    );
}