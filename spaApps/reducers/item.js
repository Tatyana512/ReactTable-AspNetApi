const initialState = {
   chooseitem: null
};

export default function item(state = initialState, action) {
    let _state,thisIndex,_elem;
    switch (action.type) {
        case 'CHOOSE_ITEM':
        _state = Object.assign({}, state, {chooseitem: action.payload});
        return _state;
        default: return _state;
    }

}