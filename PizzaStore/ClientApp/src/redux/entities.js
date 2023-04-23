import { combineReducers } from "redux";
import cartReducer from './carts'
import orderReducer from './orders'

export default combineReducers({
    carts: cartReducer,
    orders: orderReducer
})