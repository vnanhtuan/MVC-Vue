import { cartState } from '../state/cart.js';

export async function loadComponent(url) {
    const response = await fetch(url);
    const html = await response.text(); 
    return {
        template: html,
        data() {
            return {
                // Cung cấp cartItems cho template của component
                get cartItems() {
                    return cartState.items;
                }
            }
        },
        methods: {
            removeItem(item) {
                const index = cartState.items.indexOf(item);
                if (index > -1) {
                    cartState.items.splice(index, 1);
                }
            },
            checkout() {
                console.log('Checkout');
            }
        }
    }
}