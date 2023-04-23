import styles from "../styles/Cart.module.css";
import Button from '@mui/material/Button';
import Image from "next/image";
import { useRouter } from 'next/router';
import { useState } from "react";
import Link from 'next/link'
import axios from 'axios'
import { setCartTotal } from "../redux/carts";
import { useDispatch } from "react-redux";

export const getServerSideProps = async (ctx) => {

    const myCookie = ctx.req?.cookies || "";
  
    const res = await axios.get(`http://localhost:5132/api/cart`);
  
    return {
      props: {
        carts: res.data,
      },
    };
  }

const Cart = (carts) => {

    const router = useRouter()
    const dispatch = useDispatch()

    const [open, setOpen] = useState(false)

    const handleRemove = async (cartId) => {
        if (cartId) {
            const response = await axios.delete(`http://localhost:5132/api/cart/${cartId}`)
        }
    }

    let cartTotal = (carts && carts.carts && carts.carts.reduce((sum, x) => sum + parseInt(x.Price) * parseInt(x.Quantity),0))?? 0.00;

    var cartQuantity = (carts && carts.carts && carts.carts.length)?? 0.00 ;

    dispatch(setCartTotal({ ...carts, cartQuantity}))

    const handleSubmit = async (evt) => {
        evt.preventDefault()
        if (cartTotal) {
            const data = { price: cartTotal, method:0 }
            const response = await axios.post(`http://localhost:5132/api/order`, data)
            router.push(`/orders/${response.data}`)
        }
    }

    return (
        <div className={styles.container}>
            <div className={styles.left}>
            
                {carts && carts.carts && carts.carts.map(cart => (
                    <div className={styles.cartItem} key={cart.Id}>
                        <div className={styles.imageContainer}>
                            <Image
                                src={cart.ProductModel.ImageUrl}
                                layout="fill"
                                objectFit="cover"
                                alt=""
                            />
                        </div>
                        <div className={styles.cartDescription}>
                            <span className={styles.name}>{cart.ProductModel.Title}</span>
                            
                            <span className={styles.quantity}>Qty: {cart.Quantity}</span>
                            <span className={styles.total}>&#8377; {cart.Price * cart.Quantity} </span>
                            <Link href={`/cart`} passHref>
                                 <div className={styles.desc} >
                                 <Button variant="outlined" color="bg_color" onClick={() => handleRemove(cart.Id)} style={{ textTransform: "none", }}>Remove</Button>
                                </div>
                            </Link>

                        </div>
                    </div>
                ))}
                  
            </div>
            <div className={styles.right}>
                <div className={styles.wrapper}>
                    <h2 className={styles.title}>CART TOTAL</h2>
                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Subtotal:</b>&#8377; {cartTotal}
                    </div>
                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Discount:</b>&#8377; 0.00
                    </div>
                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Total:</b>&#8377; {cartTotal}
                    </div>
                    {open ?
                        <div className={styles.add}>
                            <Button size="large" variant="contained" color="bg_color"  onClick={handleSubmit} >Cash On delivery </Button>
                        </div>
                        :
                        <div className={styles.add}>
                            <Button size="large" variant="contained" color="bg_color" onClick={() => (setOpen(true))}>CheckOut Now </Button>
                        </div>}
                </div>
            </div>
        </div>
    );
};

export default Cart;