import styles from "../../styles/order.module.css";
import Button from '@mui/material/Button';
import axios from "axios"
import {apiUrl} from '../../common/constant'

export const getServerSideProps = async ({ params }) => {
    const res = await axios.get(`${apiUrl}/api/order/${params.id}`);
    return {
        props: { order: res.data },
    };
};

const Order = ({ order }) => {

    return (
        <div className={styles.container}>
            <div className={styles.right}>
                <div className={styles.wrapper}>
                <h2 className={styles.title}>Thank you!!! Your order has been placed.</h2>

                    <h2 className={styles.title}>Order Summary</h2>

                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Order Confirmation #:</b>${order.OrderId}
                    </div>

                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Subtotal:</b>${order.Price}
                    </div>
                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Discount:</b>$0.00
                    </div>
                    <div className={styles.totalText}>
                        <b className={styles.totalTextTitle}>Total:</b>${order.Price}
                    </div>
                    <div className={styles.add}>
                        <Button variant="contained" color="bg_color" style={{ cursor: "not-allowed" }}>Will be Paid on delivery </Button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Order;