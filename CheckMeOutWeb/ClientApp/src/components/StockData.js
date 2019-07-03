import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Warehouse';

class StockData extends Component {
	componentDidMount() {
		// This method is called when the component is first added to the document
		this.ensureDataFetched();
	}

	componentDidUpdate() {
		// This method is called when the route parameters change
		this.ensureDataFetched();
	}

 ensureDataFetched() {
	 this.props.requestStockItems();
 }

  render() {
	return (
	  <div>
		<h1>Avaliable Products</h1>
		<p>This component demonstrates fetching data from the server and working with URL parameters.</p>
		{renderStockTable(this.props)}
	  </div>
	);
  }
}

function renderStockTable(props) {
  return (
	<table className='table table-striped'>
	  <thead>
		<tr>
		  <th>SKU</th>
		  <th>Price</th>
		  <th>On Offer</th>
		</tr>
	  </thead>
		  <tbody>
			  {props.products.map(product =>
				  <tr key={product.sku}>
					  <td>{product.sku}</td>
					  <td>{product.price}</td>
					  <td></td>
					  <td><button className="btn btn-primary" onClick={props.addToCart}>Add</button></td>
				  </tr>
			  )}
		  </tbody>
	</table>
  );
}

export default connect(
	state => state.warehouse,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(StockData);
