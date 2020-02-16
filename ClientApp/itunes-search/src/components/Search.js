import React, { Component } from 'react';
import { Container,Input,Button } from 'reactstrap'
import ClipLoader from "react-spinners/ClipLoader";
import  MediaItem  from './MediaItem'
import { Link } from 'react-router-dom';


export class Searches extends Component {
    constructor(props) {
        super(props);
    
        this.state = {
            loading: false,
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
        if(this.state.query) {
        var user = JSON.parse(localStorage.getItem('user'));
            this.setState({loading : true});
            fetch(`https://localhost:44383/search/${user.username}/${this.state.query}`, { mode: 'cors' })
              .then(res => res.json())
              .then( data => this.setState({ items: data.results,loading: false }))
        }
        else {
            alert("cant search for empty values");
        }
      }

    render() {
        const { items } = this.state;
        var user = JSON.parse(localStorage.getItem('user'));
       
    return (
        <div>
            <div>
            <h3>Welcome: {user.username} ! </h3>
                <h1>Welcome to Search Media - Itunes</h1>
                <h4>Search Media Here:</h4>
                <br />
                <Input placeholder="Search Here"  onChange={this.setQuery} />
                <br />
                <Button color="primary" onClick={this.search}>
                    Search
                </Button>
                    <Link to="/TopSearch" className="btn btn-link">Top 10 Search</Link>
                <ClipLoader
                    size={400}
                    color={"#123abc"}
                    loading={this.state.loading}
                />
            </div>
            <Container>
                {items.map(item => (
                    <MediaItem key={item.trackId} item={item} />))}
            </Container>
        </div>
    )
    }
}
