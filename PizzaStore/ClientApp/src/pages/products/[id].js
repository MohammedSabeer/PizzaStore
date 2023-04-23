import styles from "../../styles/Product.module.css";
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Image from "next/image";
import { useState } from "react";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import { productAddedToCart } from "../../redux/carts";
import { useRouter } from "next/router";
import {apiUrl} from '../../common/constant'

export const getServerSideProps = async ({ params }) => {
    const response = await axios.get(`${apiUrl}/api/products/${params.id}`);

    return {
        props: {
            pizza: response.data
        }
    }
}

const Product = ({ pizza }) => {

    const dispatch = useDispatch()

    const [size, setSize] = useState(0);
    const [price, setPrice] = useState(pizza.Prices[0])
    const [extras, setExtras] = useState([])
    const [quantity, setQuantity] = useState(1)
    const router = useRouter()

    const changePrice = (number) => {
        setPrice(parseInt(price) + parseInt(number))
    }

    const handleSize = (sizeIndex) => {
        const difference = pizza.Prices[sizeIndex] - pizza.Prices[size]
        setSize(sizeIndex)
        changePrice(difference)
    }

    const handleChange = (e, opt) => {
        const checked = e.target.checked
        if (checked) {
            changePrice(opt.Price)
            setExtras(prev => [...prev, opt])
        } else {
            changePrice(-opt.Price)
            setExtras(extras.filter(extra => extra.Id !== opt.Id))
        }
    }
    const handleClick = async () => {

        const data = { ProductId: pizza.Id, Quantity: quantity,Toppings:extras, Price : price };
        
        await axios.post(`http://localhost:5132/api/Cart`, data)

        dispatch(productAddedToCart({ ...pizza, extras, price, quantity }))
    }

    const handleGoToCart =  () => {
        router.push(`/cart`);
    }

    const handleGoToProduct =  () => {
        router.push(`/#product`);
    }



    

    return (
        <div className={styles.container}>
            <div className={styles.left}>
                <div className={styles.imgContainer}>
                    <Image src={pizza.ImageUrl} objectFit="contain" layout="fill" alt="" />
                </div>
            </div>
            <div className={styles.right}>
                <h1 className={styles.title}>{pizza.Title}</h1>
                <span className={styles.price}>&#8377; {price}</span>
                <p className={styles.desc}>{pizza.Description}</p>
                <h3 className={styles.choose}>Choose the size</h3>
                <div className={styles.sizes}>
                    <div className={styles.size} onClick={() => handleSize(0)}>
                        <Image src="/images/size.png" layout="fill" alt="" />
                        <span className={styles.number}>Small</span>
                    </div>
                    <div className={styles.size} onClick={() => handleSize(1)}>
                        <Image src="/images/size.png" layout="fill" alt="" />
                        <span className={styles.number}>Medium</span>
                    </div>
                    <div className={styles.size} onClick={() => handleSize(2)}>
                        <Image src="/images/size.png" layout="fill" alt="" />
                        <span className={styles.number}>Large</span>
                    </div>
                </div>
                <h3 className={styles.choose}>Choose Toppings</h3>
                <div className={styles.ingredients}>
                    {pizza.ExtraOptions.map(opt => (
                        <div className={styles.option} key={opt.Id}>
                            <FormControlLabel control={<Checkbox color="bg_color" id={opt.Name} name={opt.Name} onChange={(e) => (handleChange(e, opt))} />} label={opt.Name} />
                        </div>
                    ))}
                </div>
                <div className={styles.add}>
                    <TextField onChange={(e) => setQuantity(e.target.value)} type="number" value={quantity} id="outlined-basic" color="bg_color" size="small" label="Outlined" variant="outlined" />
                    <Button variant="contained" onClick={handleClick} color="bg_color" style={{ textTransform: "none", marginLeft: "1rem" }}>Add to Cart</Button>
                    <Button variant="contained" onClick={handleGoToCart} color="bg_color" style={{ textTransform: "none", marginLeft: "1rem" }}>Go to Cart</Button>
                    <Button variant="contained" onClick={handleGoToProduct} color="bg_color" style={{ textTransform: "none", marginLeft: "1rem" }}>Add More</Button>
                </div>
               
            </div>
        </div>
    );
};

export default Product;