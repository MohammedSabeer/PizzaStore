import { createSlice } from "@reduxjs/toolkit";

const carts = createSlice({
    name: "cart",
    initialState: {
        products: [],
        total: 0,
        orderQuantity: 0
    },
    reducers: {
        productAddedToCart: (state, action) => {
            state.orderQuantity += 1
            state.products.push(action.payload)
            state.total += action.payload.price * action.payload.quantity
        },
        cartReseted: (state, action) => {
            state.products = []
            state.total = 0
            state.orderQuantity = 0
        },
        setCartTotal:(state, action)=>{
            console.log(action)
            state.orderQuantity = action.payload.cartQuantity 
        }
    }
})

export const { productAddedToCart, cartReseted, setCartTotal } = carts.actions


export default carts.reducer
