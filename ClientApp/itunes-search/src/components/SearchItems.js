// import React, { Component } from 'react'
// //import { withRouter } from 'react-router-dom'
// import { Button, Input, InputGroup, InputGroupAddon } from 'reactstrap'

// class SearchItems extends Component {
//   state = {
//     query: ''
//   }

//   setQuery = event => {
//     this.setState({ query: event.target.value })
//   }

//   search = () => {
//         fetch(`https://localhost:44383/search/${this.state.query.split(/ +/).join('+')}`, { mode: 'cors' })
//           .then(res => res.json())
//           .then(({ results }) => this.setState({ Items: results }))
//       };
  

//   render() {
//     return (
//         <div>
//             <Input placeholder="Enter a term..."  onChange={this.setQuery} />
//             <Button color="secondary" onClick={this.search}>
//                 Search
//             </Button>
//         </div>
//     )
//   }
// }

// export default SearchItems
