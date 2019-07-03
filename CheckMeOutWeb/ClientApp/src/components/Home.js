import React from 'react';
import { connect } from 'react-redux';
import StockData from './StockData';

const Home = props => (
  <div>
	<h1>Hello, Shoppers!</h1>
	<p>Welcome to the best supermarket in the world.</p>
	<StockData/>
  </div>
);

export default connect()(Home);
