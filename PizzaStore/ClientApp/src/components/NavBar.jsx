import React from 'react'
import styles from '../styles/NavBar.module.css'
import ShoppingCartCheckoutIcon from '@mui/icons-material/ShoppingCartCheckout';
import IconButton from '@mui/material/IconButton';
import Badge from '@mui/material/Badge';
import Link from 'next/link';
import { useSelector } from 'react-redux';

function NavBar() {
    const quantity = useSelector(state => state.entities.carts.orderQuantity)

    return (
        <div className={styles.container}>
            
            <div className={styles.item}>
                <ul className={styles.list}>
                <li className={styles.listItems}><Link href="/#products">Home</Link></li>
                </ul>
            </div>

            <div className={styles.item}>
                <ul className={styles.list}>
                    <li className={styles.listItems}><Link href="/#products"><h1 >Pizza hub</h1></Link></li>
                </ul>
            </div>
      
            <div className={styles.cart}>
                <Link href="/cart">
                    <a>
                        <IconButton aria-label="cart">
                            <Badge badgeContent={quantity} color="primary">
                                <ShoppingCartCheckoutIcon className={styles.cart} />
                            </Badge>
                        </IconButton>
                    </a>
                </Link>
            </div>
        </div >
    )
}

export default NavBar
