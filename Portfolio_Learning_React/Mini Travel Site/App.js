import React from "react"
import Banner from "./components/Banner"
import Cards from "./components/Cards"
import data from "./data"
export default function App() {
    const myCards = data.map(item => {
        return (
            <Cards 
            key={item.id}
            {...item}
            />
        )
    }) 
    return (
     <div>
        <Banner />
        {myCards}
     </div>
    );
}