import React from 'react'
import styles from '../styles/PizzaCard.module.css'
import Image from 'next/image'
import Link from 'next/link'


function PizzaCard({ pizza }) {
    return (
        <div key={`${pizza.Id}`} className={styles.container}>
             <Link href={`/products/${pizza.Id}`} passHref>
                <div className={styles.desc} >
                    <Image src={pizza.ImageUrl} alt="" width="500" height="500" />
                
                    <h1 className={styles.title}>{pizza.Title}</h1>
                    <span className={styles.price}>&#8377; {pizza.Prices[0]}</span>
                    <p className={styles.desc}>
                        {pizza.Description}
                    </p>
                </div>
            </Link> 
        </div>
    )
}

export default PizzaCard
