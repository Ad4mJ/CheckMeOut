const receiveProductsType = 'RECEIVE_PRODUCTS';
const requestProductsType = 'REQUEST_PRODUCTS';
const addProduct = 'ADD_PRODUCTS';
const removeProduct = 'REMOVE_PRODUCTS';
const initialState = { products: [], isLoading: false };

export const actionCreators = {
	requestStockItems: startDateIndex => async (dispatch, getState) => {

		dispatch({ type: requestProductsType });

		const url = `api/store/products`;
		const response = await fetch(url);
		const products = await response.json();

		dispatch({ type: receiveProductsType, products });
	},
	addToCart: () => ({ type: addProduct }),
	removeFromCart: () => ({ type: removeProduct })
};

export const reducer = (state, action) => {
	state = state || initialState;

	if (action.type === requestProductsType) {
		return {
			...state,
			isLoading: true
		};
	}

	if (action.type === receiveProductsType) {
		return {
			...state,
			products: action.products,
			isLoading: false
	};
  }

  return state;
};
