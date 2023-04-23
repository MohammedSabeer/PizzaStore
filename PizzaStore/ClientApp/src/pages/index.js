import axios from 'axios'
import Head from 'next/head'

import PizzaList from '../components/PizzaList'
import styles from '../styles/Home.module.css'
import {apiUrl} from '../common/constant'

export const getServerSideProps = async (ctx) => {
  const myCookie = ctx.req?.cookies || "";

  const res = await axios.get(`${apiUrl}/api/products`);
  return {
    props: {
      pizzaList: res.data,
    },
  };
}

export default function Home({ pizzaList }) {

  return (
    <div className={styles.container}>
      <Head>
        <title style={{fontWeight: 700}}>Pizza Palace - The best Pizza restaurant </title>
        <meta name="description" content="Find best pizza restaurants in India offering discounts on food & drinks" />
      </Head>
      <PizzaList pizzaList={pizzaList} />
    </div>
  )
}

 