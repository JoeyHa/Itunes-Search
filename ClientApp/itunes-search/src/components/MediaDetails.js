import React, { Component, Fragment } from 'react'
import ReactPlayer from 'react-player'
import { Media } from 'reactstrap'


export default class extends Component {
  state = {
    track: {}
  }

  componentDidMount() {
    const { id } = this.props.match.params

    fetch(`https://localhost:44383/search/Lookup/${id}`)
      .then(res => res.json())
      .then(json => this.setState({ track: json.detailsRes[0] }))
  }

  goBack = () => {
    this.props.history.goBack()
  }

  render() {
    const {
      trackName,
      artistName,
      trackPrice,
      currency,
      artworkUrl100,
      previewUrl
    } = this.state.track

    return (
      <Fragment>
        <h1>{trackName}</h1>
        <Media object src={artworkUrl100} alt={trackName} />
        <hr />
        <h2>Artist: {artistName}</h2> <br />
        <h2>Track Name: {trackName}</h2> <br />
        <h2>Price: {trackPrice} {currency}</h2> <br />
        
        <ReactPlayer controls url={previewUrl} />
        <button onClick={this.goBack}>Go Back</button>
      </Fragment>
    )
  }
}
