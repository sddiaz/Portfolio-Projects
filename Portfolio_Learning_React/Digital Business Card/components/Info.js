import React from "react"

export default function Info() {
    return (
        <div className="info">
            <img className="info--img" src="https://i.ibb.co/7Qpw6Sx/286180629-345532867715982-8100634369721424887-n.jpg"/>
            <h1 className="info--name">Santiago Diaz</h1>
            <h2 className="info--title">Aspiring Software Engineer</h2>
            <div className="webContainer">
            <a className="info--website" href="">(202)-751-5358</a>
            </div>
            <div className="info--buttons"> 
                <button onClick={emailFunction} className="info--email"><i style={{ color: '#1E1F26'}} className="fa fa-envelope fa-fw"></i>Email</button>
                 <button onClick={linkedInFunction} className="info--linkedIn"><img className="info--linkedIn--img" src="https://i.ibb.co/K2B4TTp/image.png" />LinkedIn</button>
            </div>
        </div>
    )
}
function emailFunction() {
    window.open('mailto:sddiaz2003@gmail.com?Subject=Hey%20Santiago!')
}
function linkedInFunction() {
    window.open('https://www.linkedin.com/in/santiagoddiaz/')
}