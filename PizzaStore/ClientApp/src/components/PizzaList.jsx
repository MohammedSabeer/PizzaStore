import React from 'react'
import styles from '../styles/PizzaList.module.css'
import PizzaCard from './PizzaCard'

function PizzaList({ pizzaList }) {
    return (
        <div className={styles.container}>
            <h1 className={styles.title}>Pizza Garden</h1>
            <p className={styles.desc}>
                Welcome to our delicious pizza website! We're excited to serve you. Looking for the perfect pizza? You've come to the right place! Check out our menu and find your new favorite. From classic toppings to gourmet options, we've got something for everyone. Customize your pizza just the way you like it. Thank you for choosing us for your pizza needs. We look forward to serving you!
            </p>
            <div className={styles.wrapper}>
                {pizzaList.map(pizza => {
                   return <PizzaCard key={pizza.Id} pizza={pizza} />
                }
                )}
            </div>
        </div>
    )
}

export default PizzaList
