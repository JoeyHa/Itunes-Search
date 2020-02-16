import React, { Component,Fragment } from 'react';
import { Container,Input,Button } from 'reactstrap'
//import SearchItems from './SearchItems'
import  MediaItem  from './MediaItem'

//import axios from 'axios';

export class Searches extends Component {
    constructor(props) {
        super(props);
    
        this.state = {
            items: [],
        };
    }
    setQuery = event => {
        this.setState({ query: event.target.value });
    }
    // componentDidMount() {
    //     this.search();
    // }
    componentDidUpdate(prevProps) {
        if (this.props.location.search !== prevProps.location.search) {
            this.search()
        }
    }
    search = () => {
        fetch(`https://localhost:44383/search/${this.state.query}`, { mode: 'cors' })
          .then(res => res.json())
          .then( data => this.setState({ items: data.results }))
      }


    render() {
        const { items } = this.state;
    return (
        <div>
            <div>
                <h1>Search Here:</h1>
                <br />
                <Input placeholder="Search Here"  onChange={this.setQuery} />
                <br />
                <Button color="secondary" onClick={this.search}>
                    Search
                </Button>
            </div>
            <Container>
                {items.map(item => (
                    <MediaItem key={item.trackId} item={item} />))}
            </Container>
        </div>
    )
    }
}
