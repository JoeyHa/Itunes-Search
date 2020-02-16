import React, { Component } from 'react';
import { Container,Table } from 'reactstrap'
import Topitem from './TopSearchItem'


export class TopSearch extends Component {
    constructor(props) {
        super(props);
    
        this.state = {
            loading: true,
            topSearch: [],
        };
    }
    componentDidMount() {
        this.getTop();
    }

    getTop() {
        var user = JSON.parse(localStorage.getItem('user'));
        if(user.id)
        {
            this.setState({loading : true});
                fetch(`https://localhost:44383/search/top/${user.id}`, { mode: 'cors' })
                  .then(res => res.json())
                  .then( data => this.setState({ topSearch: data,loading: false }))
        }
    }


    render() {
        const {topSearch} = this.state;
        return (
            <div>
            <h1>Top 10 Search by You:</h1>
            <Container>
                {topSearch.map(item => (
                    <Topitem key={topSearch.searchValue} Topitem={item} />))}
            </Container>
            </div>
        );
    }
}
